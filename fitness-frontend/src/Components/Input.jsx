import React from 'react'
import '../Styles/Input.css'
const Input = ({
    labelText,
    type,
    placeholder,
    name,
    value,
    onChangeHandler,
    id,
    width,
    min,
    max,
    emptyFieldError
}) => {
    const inputSize = {
        width: width,
        boxShadow: emptyFieldError ? "0px 4px 4px rgba(255, 0, 0, 0.5)" : "none"
    }
    return (
        <div className='input-container'>
            <label htmlFor={id} className='label'>
                {labelText}
            </label>
            <input className='input'
                type={type}
                placeholder={placeholder}
                id={id}
                name={name}
                value={value}
                onChange={onChangeHandler}
                style={inputSize}
                min={min}
                max={max}
            />
        </div>
    )
}

export default Input