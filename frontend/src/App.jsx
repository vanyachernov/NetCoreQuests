import { useState, useEffect } from "react"
import { Routes, Route, useLocation, Navigate } from "react-router-dom"
import ClientVerApp from "./ClientVerApp"

export default function App () {
    return (
        <>
            <div className="wrapper">
                <Routes>
                    <Route path="/" element={<ClientVerApp/>}/>
                </Routes>
            </div>
        </>
    )
}