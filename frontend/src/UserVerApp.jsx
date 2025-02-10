import { useState, useEffect } from "react"
import { Outlet, useLocation } from "react-router-dom"
import Header from "./components/UserVerApp/HeaderUser/Header"
import Sidebar from "./components/UserVerApp/SideBar/Sidebar"
import './styles/UserVerApp.scss'

export default function UserVerApp () {

    const location = useLocation()
    const [isGameUrl, setIsGameUrl] = useState(false)
    const [isActiveSidebar, setIsActiveSidebar] = useState(false)

    const handleOnClickOpenSidebar = () => {
        setIsActiveSidebar(!isActiveSidebar)
    }

    useEffect(() => {
        const path = location.pathname.replace(/\/$/, "");
        if (path.endsWith('/quest')) {
            setIsGameUrl(true)
        }
    }, [location.pathname])

    return (
        <>
            <div className={`wrapper-userver-page ${isActiveSidebar ? "active-sidebar" : ""}`}>
                {!isGameUrl && <Sidebar
                    isActiveSidebar={isActiveSidebar}
                    handleOnClickOpenSidebar={handleOnClickOpenSidebar}
                />}
                <div className="userver-page">
                    {!isGameUrl && <Header
                        handleOnClickOpenSidebar={handleOnClickOpenSidebar}
                    />}
                    <div className="outlet-container">
                        <Outlet/>
                    </div>
                </div>
            </div>
        </>
    )
}