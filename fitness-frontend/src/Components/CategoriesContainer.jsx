import React from 'react'
import '../Styles/CategoriesContainer.css'
import CategoryButton from './CategoryButton'
import allIcon from '../Icons/all.png'
import runningIcon from '../Icons/running.png'
import walkingIcon from '../Icons/walking.png'
import cyclingIcon from '../Icons/cycling.png'
import swimmingIcon from '../Icons/swimming.png'
import othersIcon from '../Icons/others.png'

const CategoriesContainer = () => {
    return (
        <div className='categories-main-container'>
            <div className='categories-column'>
                <CategoryButton
                    name="All"
                    isSelected={true}
                    icon={allIcon} />
                <CategoryButton
                    name="Running"
                    isSelected={false}
                    icon={runningIcon} />
                <CategoryButton
                    name="Walking"
                    isSelected={false}
                    icon={walkingIcon} />
            </div>
            <div className='categories-column'>
                <CategoryButton
                    name="Cycling"
                    isSelected={false}
                    icon={cyclingIcon} />
                <CategoryButton
                    name="Swimming"
                    isSelected={false}
                    icon={swimmingIcon} />
                <CategoryButton
                    name="Others"
                    isSelected={false}
                    icon={othersIcon} />
            </div>
        </div>
    )
}

export default CategoriesContainer