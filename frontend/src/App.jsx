import { useState, useEffect } from "react"
import { Routes, Route, useLocation, Navigate } from "react-router-dom"
import ClientVerApp from "./ClientVerApp"
import AuthForm from "./components/ClientVerApp/Auth/AuthForm"
import UserVerApp from "./UserVerApp"
import GamePage from "./components/UserVerApp/GamePage/GamePage"

export default function App () {
    return (
        <>
            <div className="wrapper">
                <Routes>
                    <Route path="/" element={<ClientVerApp/>}/>
                    <Route path="/auth" element={<AuthForm/>}/>
                    <Route path="/app" element={<UserVerApp/>}>
                        <Route path="quest" element={<GamePage/>} />
                    </Route>
                </Routes>
            </div>
        </>
    )
}