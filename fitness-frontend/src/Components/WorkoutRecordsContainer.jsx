import React from 'react'
import WorkoutRecord from './WorkoutRecord'
import '../Styles/WorkoutRecordsContainer.css'
import uuid from '../Utils/key'

const WorkoutRecordsContainer = ({
    month,
    year,
    monthOverview,
    monthWorkoutRecords
}) => {
    const monthRecord = monthWorkoutRecords.map(
        (monthRecord) => (
            <div key={uuid()}>
                <hr className='separator'></hr>
                <WorkoutRecord
                    workoutInfo={monthRecord}
                />
            </div>
        )
    )
    return (
        <div className='workout-records-container'>
            <div className='month-year-overview-container'>
                <h1 className='month-year-header'>
                    {month} {year}</h1>
                <h2 className='month-overview-header'>
                    {monthOverview}
                </h2>
            </div>
            {monthRecord}
        </div>
    )
}

export default WorkoutRecordsContainer