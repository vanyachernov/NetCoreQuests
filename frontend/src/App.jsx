import { useState, useEffect } from "react"
import { Routes, Route, useLocation, Navigate } from "react-router-dom"
import ClientVerApp from "./ClientVerApp"
import AuthForm from "./components/ClientVerApp/Auth/AuthForm"

export default function App () {
    return (
        <>
            <div className="wrapper">
                <Routes>
                    <Route path="/" element={<ClientVerApp/>}/>
                    <Route path="/auth" element={<AuthForm/>}/>
                </Routes>
            </div>
        </>
    )
}