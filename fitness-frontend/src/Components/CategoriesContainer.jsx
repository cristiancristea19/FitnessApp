import React from 'react'
import '../Styles/CategoriesContainer.css'
import CategoryButton from './CategoryButton'
import allIcon from '../Icons/all.png'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import othersIcon from '../Icons/others.png'

const CategoriesContainer = ({
    buttonArray,
    onClickFunction
}) => {
    return (
        <div className='categories-main-container'>
            <div className='categories-column'>
                <CategoryButton
                    name="All"
                    isSelected={buttonArray[5]}
                    icon={allIcon}
                    onClickFunction={onClickFunction}
                    Id="5" />
                <CategoryButton
                    name="Running"
                    isSelected={buttonArray[0]}
                    icon={runningIcon}
                    onClickFunction={onClickFunction}
                    Id="0" />
                <CategoryButton
                    name="Walking"
                    isSelected={buttonArray[1]}
                    icon={walkingIcon}
                    onClickFunction={onClickFunction}
                    Id="1" />
            </div>
            <div className='categories-column'>
                <CategoryButton
                    name="Cycling"
                    isSelected={buttonArray[2]}
                    icon={cyclingIcon}
                    onClickFunction={onClickFunction}
                    Id="2" />
                <CategoryButton
                    name="Swimming"
                    isSelected={buttonArray[3]}
                    icon={swimmingIcon}
                    onClickFunction={onClickFunction}
                    Id="3" />
                <CategoryButton
                    name="Others"
                    isSelected={buttonArray[4]}
                    icon={othersIcon}
                    onClickFunction={onClickFunction}
                    Id="4" />
            </div>
        </div>
    )
}

export default CategoriesContainer