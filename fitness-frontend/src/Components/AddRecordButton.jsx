import React from 'react'
import '../Styles/AddRecordButton.css'

const AddRecordButton = ({
    onClickFunction
}) => {
    return (
        <div>
            <button
                className='add-record-btn'
                onClick={onClickFunction}>
                <span className='icon-add'
                >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span>
                Add Workout Record
            </button>
        </div>
    )
}

export default AddRecordButton