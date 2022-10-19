import React from 'react'
import '../Styles/WorkoutRecord.css'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import otherIcon from '../Icons/all.png'

const WorkoutRecord = ({
    workoutInfo
}) => {
    const activityTypes = ["Running", "Walking", "Cycling", "Swimming", "Others"]
    let icon
    switch (workoutInfo.activityType) {
        case 0:
            icon = runningIcon
            break
        case 1:
            icon = walkingIcon
            break
        case 2:
            icon = cyclingIcon
            break
        case 3:
            icon = swimmingIcon
            break
        case 4:
            icon = otherIcon
            break
    }
    return (
        <div className="workout-record-main-container">
            <img src={icon} className='workout-icon' />
            <div className='info-container'>
                <div className='category-time-container'>
                    <h2 className='category-time-header'>
                        {activityTypes[workoutInfo.activityType]}
                    </h2>
                    <h2 className='category-time-header'>
                        {workoutInfo.time}
                    </h2>
                </div>
                <div className='workout-info-container'>
                    <div className='mini-info-container'>
                        <h1 className='workout-info-header'>
                            {workoutInfo.distance}
                        </h1>
                        <h3 className='um-header'>km</h3>
                    </div>
                    <h1 className='workout-info-header'>
                        {workoutInfo.duration}
                    </h1>
                    <div className='mini-info-container'>
                        <h1 className='workout-info-header'>
                            {workoutInfo.calories}
                        </h1>
                        <h3 className='um-header'>kcal</h3>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default WorkoutRecord