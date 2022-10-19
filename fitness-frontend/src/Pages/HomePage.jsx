import React, { useEffect } from 'react'
import CategoriesContainer from '../Components/CategoriesContainer'
import Overview from '../Components/Overview'
import '../Styles/HomePage.css'
import Navbar from '../Components/Navbar'
import AddRecordButton from '../Components/AddRecordButton'
import GetWorkoutRecordsApi from '../Api/GetWorkoutRecordsApi'
import MonthsRecords from '../Components/MonthsRecords'
import { useState } from 'react'

const HomePage = () => {
    const workoutsInfo = [{
        category: "Swimming",
        time: "May 26 20:04",
        distance: "1.6",
        duration: "00:20:35",
        calories: "120"
    },
    {
        category: "Cycling",
        time: "May 27 20:04",
        distance: "1.6",
        duration: "00:20:35",
        calories: "120"
    }]
    const monthsWorkoutInfo = [{
        month: "May",
        year: "2021",
        monthOverview: "3.50 km 35.94 min 2 times 234 kcal",
        workoutsInfo: workoutsInfo
    },
    {
        month: "Jun",
        year: "2021",
        monthOverview: "3.50 km 35.94 min 2 times 234 kcal",
        workoutsInfo: workoutsInfo
    }]

    const [overview, setOverview] = useState({
        duration: 0.0,
        numberOfSessions: 0,
        calories: 0
    })

    const [monthSummaries, setMonthSummaries] = useState([])

    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "Octomber", "November", "December"]

    const overviewFormat = (km, min, times, kcal) => {
        return `${km} km ${min} min ${times} times ${kcal} kcal`
    }

    const getWorkoutRecords = async () => {
        const response = await GetWorkoutRecordsApi(JSON.parse(localStorage.getItem("userId")))
        setOverview({
            duration: response.overview.duration.toFixed(2),
            numberOfSessions: response.overview.numberOfSessions,
            calories: response.overview.calories
        })
        response.overview.monthSummaries.forEach(element => {
            setMonthSummaries(old =>
                [...old,
                {
                    month: months[element.month - 1],
                    year: element.year,
                    overview: overviewFormat(
                        element.totalDistance.toFixed(2),
                        element.totalTime.toFixed(2),
                        element.numberOfTimes,
                        element.calories,
                    ),
                    workoutRecords: element.workoutRecords
                }])
        });
    }

    useEffect(() => {
        getWorkoutRecords()
    }, [])

    return (
        <div className='home-page-main-container'>
            <Navbar
                username="cristiancristea19"
            />
            <div className='overview_categories-container'>
                <Overview
                    duration={overview.duration}
                    numberOfSessions={overview.numberOfSessions}
                    numberOfCalories={overview.calories}
                />
                <CategoriesContainer />
            </div>
            <div className='add-record-container'>
                <AddRecordButton />
            </div>
            <div className='workout-records-home'>
                <MonthsRecords
                    monthsRecordsInfo={monthSummaries}
                />
            </div>
        </div>
    )
}

export default HomePage