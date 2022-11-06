import React from 'react'
import '../Styles/ComponentButton.css'

const ComponentButton = ({
    text,
    onClickFunction
}) => {
    return (
        <div>
            <button
                className='component-btn'
                onClick={onClickFunction}
            >
                {text}
            </button>
        </div>
    )
}

export default ComponentButton