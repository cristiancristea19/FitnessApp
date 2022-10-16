import React from 'react'
import '../Styles/WorkoutRecord.css'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import othersIcon from '../Icons/others.png'

const WorkoutRecord = ({
    workoutInfo
}) => {
    let icon
    switch (workoutInfo.category) {
        case "Running":
            icon = runningIcon
            break
        case "Walking":
            icon = walkingIcon
            break
        case "Cycling":
            icon = cyclingIcon
            break
        case "Swimming":
            icon = swimmingIcon
            break
    }
    return (
        <div className="workout-record-main-container">
            <img src={icon} className='workout-icon' />
            <div className='info-container'>
                <div className='category-time-container'>
                    <h2 className='category-time-header'>
                        {workoutInfo.category}
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