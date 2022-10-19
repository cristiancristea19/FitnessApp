import React from 'react'
import WorkoutRecordsContainer from './WorkoutRecordsContainer'
import uuid from '../Utils/key'

const MonthsRecords = ({
    monthsRecordsInfo
}
) => {
    console.log(monthsRecordsInfo)
    const WorkoutRecordsContainers = monthsRecordsInfo.map(
        (monthRecord) =>
        (
            <WorkoutRecordsContainer
                key={uuid()}
                month={monthRecord.month}
                year={monthRecord.year}
                monthOverview={monthRecord.overview}
                monthWorkoutRecords={monthRecord.workoutRecords}
            />
        ))
    return (
        <div className='months-records'>
            {WorkoutRecordsContainers}
        </div>
    )
}

export default MonthsRecords