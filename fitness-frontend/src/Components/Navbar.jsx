import React from 'react'
import personIcon from '../Icons/person-circle.png'
import '../Styles/Navbar.css'
import LogOutButton from './LogOutButton'

const Navbar = ({
    username,
    onClickFunction
}) => {
    return (
        <div className='navbar-container'>
            <h1 className='app-name'>FitnessTracker</h1>
            <div className='user-container'>
                <h1 className='username'>{username}</h1>
                <img src={personIcon} className="person-icon" />
                <LogOutButton onClickFunction={onClickFunction} />
            </div>
        </div>
    )
}

export default Navbar