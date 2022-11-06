import React, { useState } from 'react'
import ReactModal from 'react-modal'
import '../Styles/AddWorkoutRecordModal.css'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import othersIcon from '../Icons/others.png'
import CategoryButton from './CategoryButton'
import Button from './Button'
import AddWorkoutRecordApi from '../Api/AddWorkoutRecordApi'

const AddEditWorkoutRecordModal = ({
    isOpen,
    setOpen,
    refreshPage,
    workoutInfo
}) => {
    const [buttonArray, setButtonArray] = useState([true, false, false, false, false])

    const chooseActivityType = event => {
        let newBtn = Array(5).fill(false)
        const activityType = parseInt(event.currentTarget.id)
        newBtn[activityType] = true
        setButtonArray(newBtn)
    }

    const [formData, setFromData] = useState({
        distance: workoutInfo === undefined ? 0.0 : workoutInfo.distances,
        h: 0,
        min: 0,
        s: 0,
        calories: workoutInfo === undefined ? 0.0 :
            workoutInfo.calories
    })

    const handleFormData = (event) => {
        let { name, value } = event.target
        if (value < 0) value = 0
        setFromData(prevFormData => {
            return {
                ...prevFormData,
                [name]: value
            }
        })
    }

    const addWorkoutRecord = async () => {
        const response = await AddWorkoutRecordApi(
            (JSON.parse(localStorage.getItem("user"))).id,
            formData.distance,
            formData.h,
            formData.min,
            formData.s,
            formData.calories,
            buttonArray.indexOf(true)
        )
        refreshPage()
        closeModal()
    }

    const closeModal = () => {
        setFromData({
            distance: 0.0,
            h: 0,
            min: 0,
            s: 0,
            calories: 0
        })
        setButtonArray([true, false, false, false, false])
        setOpen(false)
    }

    return (
        <ReactModal
            isOpen={isOpen}
            style=
            {{
                overlay: { backgroundColor: '#00000078' },
                content: {
                    borderRadius: '20px',
                    margin: 'auto',
                    height: '600px',
                    width: '600px',
                    padding: '20px'
                }
            }}
            ariaHideApp={false}
        >
            <h1 className='add-workout-header'>Add Workout Record</h1>
            <div className='activity-container'>
                <div className='activity-left-column'>
                    <h2 className='category-title'>Choose activity</h2>
                    <CategoryButton
                        name="Running"
                        isSelected={buttonArray[0]}
                        icon={runningIcon}
                        onClickFunction={chooseActivityType}
                        Id="0" />
                    <CategoryButton
                        name="Walking"
                        isSelected={buttonArray[1]}
                        icon={walkingIcon}
                        onClickFunction={chooseActivityType}
                        Id="1" />
                    <CategoryButton
                        name="Cycling"
                        isSelected={buttonArray[2]}
                        icon={cyclingIcon}
                        onClickFunction={chooseActivityType}
                        Id="2" />
                </div>
                <div className='activity-right-column'>

                    <CategoryButton
                        name="Swimming"
                        isSelected={buttonArray[3]}
                        icon={swimmingIcon}
                        onClickFunction={chooseActivityType}
                        Id="3" />
                    <CategoryButton
                        name="Others"
                        isSelected={buttonArray[4]}
                        icon={othersIcon}
                        onClickFunction={chooseActivityType}
                        Id="4" />
                </div>

            </div>
            <hr className='separator-m'></hr>
            <div className='distance-container'>
                <label htmlFor="distance-input" className='category-title'>
                    Distance
                </label>
                <input className='input'
                    id="distance-input"
                    type="number"
                    step={0.1}
                    placeholder="0,0"
                    name="distance"
                    onChange={handleFormData}
                    min={0}
                    max={1000}
                    value={formData.distance}
                />
                <h2 className='category-title'>km</h2>
            </div>
            <hr className='separator-m'></hr>
            <div className='duration-container'>
                <label htmlFor="duration-input" className='category-title'>
                    Duration
                </label>
                <div className='h-m-s-container'>
                    <div className='h-container'>
                        <input className='input'
                            id="h-input"
                            type="number"
                            placeholder="0"
                            name="h"
                            onChange={handleFormData}
                            min={0}
                            max={1000}
                            value={formData.h}
                        />
                        <h2 className='category-title'>h</h2>
                    </div>
                    <div className='h-container'>
                        <input className='input'
                            id="min-input"
                            type="number"
                            placeholder="0"
                            name="min"
                            onChange={handleFormData}
                            min={0}
                            max={59}
                            value={formData.min}
                        />
                        <h2 className='category-title'>min</h2>
                    </div>
                    <div className='h-container'>
                        <input className='input'
                            id="s-input"
                            type="number"
                            placeholder="0"
                            name="s"
                            onChange={handleFormData}
                            min={0}
                            max={59}
                            value={formData.s}
                        />
                        <h2 className='category-title'>s</h2>
                    </div>
                </div>
            </div>
            <hr className='separator-m'></hr>
            <div className='calories-container'>
                <label htmlFor="calories-input" className='category-title'>
                    Calories
                </label>
                <input className='input'
                    id="calories-input"
                    type="number"
                    placeholder="0"
                    name="calories"
                    onChange={handleFormData}
                    min={0}
                    max={100000}
                    value={formData.calories}
                />
                <h2 className='category-title'>kcal</h2>
            </div>
            <div className='btn-container'>
                <Button
                    text="Cancel"
                    onClickFunction={closeModal}
                />
                <Button
                    text="Add"
                    onClickFunction={addWorkoutRecord}
                />
            </div>
        </ReactModal>
    )
}

export default AddEditWorkoutRecordModal