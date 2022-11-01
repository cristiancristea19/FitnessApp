import React from 'react'
import icon from '../Icons/empty.png'
import '../Styles/NoWorkoutRecordComponent.css'

const NoWorkoutRecordComponent = () => {
  return (
    <div className='no-workout-main-div'>
      <h1 className='no-workout-header'>No workout record</h1>
      <img src={icon} />
    </div>
  )
}

export default NoWorkoutRecordComponent