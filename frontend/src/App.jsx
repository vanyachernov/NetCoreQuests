import { useState, useEffect } from "react"
import { Routes, Route, useLocation, Navigate } from "react-router-dom"
import ClientVerApp from "./ClientVerApp"
import AuthForm from "./components/ClientVerApp/Auth/AuthForm"
import ProtectedRouteApp from "./components/UserVerApp/ProtectedRoute/ProtectedRouteApp"
import UserPanel from "./components/UserVerApp/UserPanel/UserPanel"
import Quests from "./components/UserVerApp/Quests/Quests"
import CreateQuest from "./components/UserVerApp/CreateQuest/CreateQuest"
import GamePage from "./components/UserVerApp/GamePage/GamePage"
import UserVerApp from "./UserVerApp"

export default function App () {
    return (
        <>
            <div className="wrapper">
                <Routes>
                    <Route path="/" element={<ClientVerApp/>}/>
                    <Route path="/auth" element={<AuthForm/>}/>
                    <Route path="/app" element={<ProtectedRouteApp/>}>
                        <Route path="user/:username" element={<UserPanel/>}/>
                        <Route index path="quests" element={<Quests/>}/>
                        <Route path="create" element={<CreateQuest/>}/>
                        {/* <Route path="quest" element={<GamePage/>} /> */}
                    </Route>
                </Routes>
            </div>
        </>
    )
}