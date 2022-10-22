import React from 'react'
import '../Styles/CategoryButton.css'

const CategoryButton = ({
    name,
    isSelected,
    icon,
    onClickFunction,
    Id
}) => {
    const color = {
        backgroundColor: isSelected ? "var(--green-two)" : " var(--green-one)"
    }

    const iconUrl = {
        backgroundImage: `url(${icon})`,
        backgroundRepeat: 'no-repeat'
    }
    return (
        <div>
            <button
                className='category-btn'
                onClick={onClickFunction}
                style={color}
                id={Id}
            >
                <span className='icon'
                    style={iconUrl}
                >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>{name}
            </button>
        </div>
    )
}

export default CategoryButton