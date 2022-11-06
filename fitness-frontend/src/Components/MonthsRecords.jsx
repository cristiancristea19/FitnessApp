import React from 'react'
import WorkoutRecordsContainer from './WorkoutRecordsContainer'
import uuid from '../Utils/key'

const MonthsRecords = ({
    monthsRecordsInfo,
    refreshPage
}
) => {
    const WorkoutRecordsContainers = monthsRecordsInfo.map(
        (monthRecord) =>
        (
            <WorkoutRecordsContainer
                key={uuid()}
                month={monthRecord.month}
                year={monthRecord.year}
                monthOverview={monthRecord.overview}
                monthWorkoutRecords={monthRecord.workoutRecords}
                refreshPage={refreshPage}
            />
        ))
    return (
        <div className='months-records'>
            {WorkoutRecordsContainers}
        </div>
    )
}

export default MonthsRecords