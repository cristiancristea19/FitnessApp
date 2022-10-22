import React from 'react'
import '../Styles/LogOutButton.css'

const AddRecordButton = ({
    onClickFunction
}) => {
    return (
        <div>
            <button
                className='log-out-btn'
                onClick={onClickFunction}>
                Log Out
            </button>
        </div>
    )
}

export default AddRecordButton