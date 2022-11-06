import React from 'react'
import '../Styles/LogOutButton.css'

const LogOutButton = ({
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

export default LogOutButton