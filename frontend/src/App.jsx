import { useState, useEffect } from "react"
import { Routes, Route, useLocation, Navigate } from "react-router-dom"
import ClientVerApp from "./ClientVerApp"
import AuthForm from "./components/ClientVerApp/Auth/AuthForm"
import ProtectedRouteApp from "./components/UserVerApp/ProtectedRoute/ProtectedRouteApp"
import UserPanel from "./components/UserVerApp/UserPanel/UserPanel"
import Quests from "./components/UserVerApp/Quests/Quests"
import CreateQuest from "./components/UserVerApp/CreateQuest/CreateQuest"
import QuestPage from "./components/UserVerApp/QuestPage/QuestPage"
import GamePage from "./components/UserVerApp/GamePage/GamePage"
import UserVerApp from "./UserVerApp"

export default function App () {
    return (
        <>
            <div className="wrapper">
                <Routes>
                    <Route path="/" element={<ClientVerApp/>}/>
                    <Route path="/auth" element={<AuthForm/>}/>
                    <Route path="/quest/:questId" element={<QuestPage/>}/>
                    <Route path="/play/:id" element={<GamePage/>}/>
                    <Route path="/app" element={<UserVerApp/>}>
                        <Route index element={<Navigate to="quests" replace/>}/>
                        <Route path="user/:username" element={<UserPanel/>}/>
                        <Route path="quest/:questId" element={<QuestPage/>}/>
                        <Route path="play/:id" element={<GamePage/>}/>
                        <Route path="quests" element={<Quests/>}/>
                        <Route path="create" element={<CreateQuest/>}/>
                    </Route>
                </Routes>
            </div>
        </>
    )
}