import { useState, useEffect } from "react"
import { useUserInformationStore } from "../../../store/userStore/userInformationStore/userInformationStore.js"
import { Navigate } from "react-router-dom"
import UserVerApp from "../../../UserVerApp"

export default function ProtectedRouteApp () {

    const {userData, isValid, checkExpiration} = useUserInformationStore()

    useEffect(() => {
        if (userData) {
            checkExpiration()
        }
    },[])

    return (
        <>
            {
                isValid ? <UserVerApp/> : <Navigate to={'/auth'} replace/>
            }
        </>
    )
}