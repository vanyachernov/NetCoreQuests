import { useState, useEffect } from "react"
import { useUserInformationStore } from "../../../store/userStore/userInformationStore/userInformationStore"
import { Navigate } from "react-router-dom"
import UserVerApp from "../../../UserVerApp"
import axios from "axios"

export default function ProtectedRouteApp () {

    const [authStatus, setAuthStatus] = useState({
        errorLogin: null,
        isLoginned: false,
        isLoading: true
    })

    useEffect(() => {
        const checkLogin = async () => {
            try {
                
                const response = await axios.get()

                if (response.status === 200) {
                    setAuthStatus(prevStatus => ({
                        ...prevStatus,
                        errorLogin: null,
                        isLoginned: true,
                        isLoading: false
                    }))
                } else if (response.status === 404) {
                    setAuthStatus(prevStatus => ({
                        ...prevStatus,
                        errorLogin: response.data.message,
                        isLoginned: false,
                        isLoading: false
                    }))
                } else {
                    setAuthStatus(prevStatus => ({
                        ...prevStatus,
                        errorLogin: 'Unexpected error occurred',
                        isLoginned: false,
                        isLoading: false
                    }))
                }

            } catch (error) {
                setAuthStatus(prevStatus => ({
                    ...prevStatus,
                    errorLogin: error.response?.data.message || error.message,
                    isLoginned: false,
                    isLoading: false
                }))
                console.error("Error: api check login", error)
            }
        }
        checkLogin()
    },[])

    return (
        <>
            {authStatus.errorLogin && 
                <div className="error-block">
                    <h3 className="error-block__h3">
                        {authStatus.errorLogin}
                    </h3>
                </div>
            }
            {
                authStatus.isLoginned ? <UserVerApp/> : <Navigate to={'/auth'} replace/>
            }
        </>
    )
}