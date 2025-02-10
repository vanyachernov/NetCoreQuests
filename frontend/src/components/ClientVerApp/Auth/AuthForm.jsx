import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import axios from "axios";
import './AuthForm.scss'

export default function AuthForm () {

    const [isLogin, setIsLogin] = useState(true)
    const {register, handleSubmit, formState: {errors, isValid}} = useForm({
        mode: "onChange"
    })

    const inputErrors = {
        email: {
          message: errors.email?.message || null
        },
        password: {
          message: errors.password?.message || null
        },
        name: {
          message: errors.name?.message || null
        },
    }

    const onSubmit = async (data) => {
        try {
            
        } catch (error) {
            
        }
    }

    const handleOnClickLink = () => {
        setIsLogin(!isLogin)
    }

    return (
        <>
            <div className='wrapper-login-page'>
                <div className='login-page'>
                    <div className="container-login-page">
                        <div className='login-title'>
                            <h3 className='login-title__h3'>
                                {isLogin ? 'Login to your account' : 'Create a new account'}
                            </h3>
                        </div>
                        <form onSubmit={handleSubmit(onSubmit)} className="login-form">
                            <div className='wrapper-input-sections'>
                                {!isLogin && (
                                    <FormField
                                        label={"Name"}
                                        name={"name"}
                                        type={"text"}
                                        register={register}
                                        inputErrors={inputErrors}
                                        validationRules={{
                                            required: 'This field must not be empty'
                                        }}

                                    />
                                )}
                                <FormField
                                    label={"Email address"}
                                    name={"email"}
                                    type={"email"}
                                    register={register}
                                    inputErrors={inputErrors}
                                    validationRules={{
                                        required: 'Invalid email type',
                                        pattern: {
                                            value: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                                            message: 'Invalid email type'
                                        },
                                    }}
                                />
                                <FormField
                                    label={"Password"}
                                    name={"password"}
                                    type={"password"}
                                    register={register}
                                    inputErrors={inputErrors}
                                    validationRules={{
                                        required: 'This field must not be empty'
                                    }}
                                />
                            </div>
                            <div className='wrapper-login-button'>
                                <button disabled={!isValid} type='submit' className='login-form__button'>
                                    {isLogin ? 'Sign in' : 'Sign up'}
                                </button>
                            </div>
                        </form>
                        <div className='wrapper-login-footer-section'>
                            <div className='login-footer-section'>
                                <p className='login-footer-section__p'>
                                    {isLogin ? 'No account yet?' : 'Already have an account?'}
                                </p>
                                <p onClick={handleOnClickLink} className='login-footer-section__link'>
                                    {isLogin ? 'Create an account' : 'Log in'}
                                </p>
                            </div>
                            <div className='login-footer-section'>
                                <p className='login-footer-section__p'>
                                    {isLogin ? 'Don\'t want Login?' : 'Don\'t want SignUp?'}
                                </p>
                                <Link to={'/'} className='login-footer-section__link'>Return to Home Page</Link>
                            </div>
                        </div> 
                    </div>
                </div>
            </div>
        </>
    )
}

function FormField ({label, name, type, inputErrors, register, validationRules}) {

    const fieldError = inputErrors?.[name]?.message;

    return (
        <>
            <div className='wrapper-input-section'>
                <label className='login-form__label' htmlFor={label}>{label}</label>
                <input autoComplete="off" name={name} type={type} id={label} className='login-form__input'
                    {...register(name, {...validationRules})}
                />
                {fieldError && <p className='login-input-error__p'>{fieldError}</p>}
            </div>
        </>
    )
}