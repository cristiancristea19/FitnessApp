import React from 'react'
import CategoriesContainer from '../Components/CategoriesContainer'
import Overview from '../Components/Overview'
import '../Styles/HomePage.css'
import Navbar from '../Components/Navbar'
import AddRecordButton from '../Components/AddRecordButton'
import WorkoutRecord from '../Components/WorkoutRecord'
import WorkoutRecordsContainer from '../Components/WorkoutRecordsContainer'
import MonthsRecords from '../Components/MonthsRecords'

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
    return (
        <div className='home-page-main-container'>
            <Navbar
                username="cristiancristea19"
            />
            <div className='overview_categories-container'>
                <Overview
                    duration={1.6}
                    numberOfSessions={6}
                    numberOfCalories={460}
                />
                <CategoriesContainer />
            </div>
            <div className='add-record-container'>
                <AddRecordButton />
            </div>
            <div className='workout-records-home'>
                {/* <WorkoutRecordsContainer
                    month="May"
                    year="2021"
                    monthOverview="3.50 km 35.94 min 2 times 234 kcal"
                    monthWorkoutRecords={workoutsInfo}
                /> */}
                <MonthsRecords
                    monthsRecordsInfo={monthsWorkoutInfo}
                />
            </div>
        </div>
    )
}

export default HomePage