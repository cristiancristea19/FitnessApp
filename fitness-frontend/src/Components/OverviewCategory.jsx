import React from 'react'
import '../Styles/OverviewCategory.css'

const OverviewCategory = ({
    categoryName,
    categoryData
}) => {
    return (
        <div className='overview-category-container'>
            <h1 className='category-data'>{categoryData}</h1>
            <h2 className='category-name'>{categoryName}</h2>
        </div>
    )
}

export default OverviewCategory