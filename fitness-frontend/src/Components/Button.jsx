import React from 'react'
import '../Styles/Button.css'

const Button = ({
    text,
    onClickFunction,
}) => {
    return (
        <div>
            <button className='btn' onClick={onClickFunction}>
                {text}
            </button>
        </div>
    )
}

export default Button