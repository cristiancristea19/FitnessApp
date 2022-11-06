import React from 'react'
import '../Styles/WorkoutRecord.css'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import otherIcon from '../Icons/others.png'
import { months } from '../Utils/Constants'
import ComponentButton from './ComponentButton'
import { useState } from 'react'
import ConfirmationMessageModal from './ConfirmationMessageModal'

const WorkoutRecord = ({
    workoutInfo,
    refreshPage
}) => {
    const activityTypes = ["Running", "Walking", "Cycling", "Swimming", "Others"]
    let icon

    const [isConfirmationMessageModalOpen, setConfimationMessageModalOpen] = useState(false)

    const getDate = () => {
        const strs = workoutInfo.date.split('-')
        const month = months[parseInt(strs[1]) - 1]
        const strs1 = strs[2].split('T')
        const day = strs1[0]
        const strs2 = strs1[1].split(':')
        const hour = strs2[0]
        const minutes = strs2[1]
        return `${month} ${day} ${hour}:${minutes}`
    }

    const openConfirmationMessageModal = () => {
        setConfimationMessageModalOpen(true)
    }

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
            <ConfirmationMessageModal
                text='Are you sure that you want to delete this workout record?'
                isOpen={isConfirmationMessageModalOpen}
                setOpen={setConfimationMessageModalOpen}
                refreshPage={refreshPage}
                workoutId={workoutInfo.id}
                buttonText='Delete'
            />
            <img src={icon} className='workout-icon' />
            <div className='info-container'>
                <div className='category-time-container'>
                    <h2 className='category-time-header'>
                        {activityTypes[workoutInfo.activityType]}
                    </h2>
                    <div className='time-btns-container'>
                        <h2 className='category-time-header'>
                            {getDate()}
                        </h2>
                        <ComponentButton
                            text='Delete'
                            onClickFunction={openConfirmationMessageModal}
                        />
                        <ComponentButton
                            text='Edit'
                        />
                    </div>
                </div>
                <div className='workout-info-container'>
                    <h1 className='workout-info-header'>
                        {workoutInfo.duration}
                    </h1>
                    <div className='mini-info-container'>
                        <h1 className='workout-info-header'>
                            {workoutInfo.distance}
                        </h1>
                        <h3 className='um-header'>km</h3>
                    </div>
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