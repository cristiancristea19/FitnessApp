import React from 'react'
import '../Styles/Overview.css'
import OverviewCategory from './OverviewCategory'

const Overview = ({
    duration,
    numberOfSessions,
    numberOfCalories
}) => {
    return (
        <div className='overview-main-container'>
            <div className='overview-title-container'>
                <h1 className='overview-title'>Overview</h1>
            </div>
            <div className='overview-data-container'>
                <OverviewCategory
                    categoryData={duration}
                    categoryName={"Duration(h)"}
                />
                <h1 className='overview-separator' />
                <OverviewCategory
                    categoryData={numberOfSessions}
                    categoryName={"Sessions"}
                />
                <h1 className='overview-separator' />
                <OverviewCategory
                    categoryData={numberOfCalories}
                    categoryName={"Calories(kcal)"}
                />
            </div>
        </div>
    )
}

export default Overview