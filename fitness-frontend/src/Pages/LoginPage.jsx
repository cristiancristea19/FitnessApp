import React, { useState } from 'react'
import Input from '../Components/Input'
import Button from '../Components/Button'
import LeftSidePhoto from '../Components/LeftSidePhoto'
import '../Styles/LoginPage.css'
import { useNavigate } from 'react-router-dom'
import LogInApi from '../Api/LogInApi'

const LoginPage = () => {
    const [formData, setFromData] = useState({
        username: "",
        password: ""
    })
    const [emptyUsernameError, setEmptyUsernameError] = useState(false)
    const [emptyPasswordError, setEmptyPasswordError] = useState(false)
    const [errorMessage, setErrorMessage] = useState("")
    const navigate = useNavigate()

    const handleFormData = (event) => {
        const { name, value } = event.target
        setFromData(prevFormData => {
            return {
                ...prevFormData,
                [name]: value
            }
        })
    }

    const validateFormData = () => {
        setEmptyUsernameError(false);
        setEmptyPasswordError(false);
        setErrorMessage("")
        if (!formData.username && !formData.password) {
            setEmptyUsernameError(true);
            setEmptyPasswordError(true);
            setErrorMessage("Username and password are mandatory!")
            return false
        } else if (!formData.username) {
            setEmptyUsernameError(true);
            setErrorMessage("Username is mandatory!")
            return false
        } else if (!formData.password) {
            setEmptyPasswordError(true);
            setErrorMessage("Password is mandatory!")
            return false
        }
        return true;
    }

    const signUpFunction = () => {
        navigate("/register")
    }


    const loginFunction = async () => {
        if (validateFormData()) {
            const response = await LogInApi(
                formData.username,
                formData.password
            )
            if (response.isError) {
                setEmptyUsernameError(true);
                setEmptyPasswordError(true);
                setErrorMessage("Invalid credentials!")
            } else {
                localStorage.setItem("user", JSON.stringify(
                    {
                        id: response.user.id,
                        username: response.user.username
                    }))
                navigate("/home")
            }
        }

    }

    return (
        <div className='login-main-container'>
            <LeftSidePhoto />
            <div className='right-side-login'>
                <div className='inputs-container'>
                    <Input
                        labelText='Username'
                        type='text'
                        placeholder='Enter your username here...'
                        name='username'
                        id='username'
                        onChangeHandler={handleFormData}
                        emptyFieldError={emptyUsernameError}
                    />
                    <Input
                        labelText='Password'
                        type='password'
                        placeholder='Enter your password here...'
                        name='password'
                        id='password'
                        onChangeHandler={handleFormData}
                        emptyFieldError={emptyPasswordError}
                    />
                    {errorMessage ? <p className='error-message'>{errorMessage}</p> : <div className='no-error-message'> </div>}
                </div>
                <div className='buttons-container'>
                    <Button
                        text='Sign Up'
                        onClickFunction={signUpFunction}
                    />
                    <Button
                        text='Log In'
                        onClickFunction={loginFunction}
                    />
                </div>
            </div>

        </div>
    )
}

export default LoginPage
