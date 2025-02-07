import { useRef } from "react"
import Header from "./components/ClientVerApp/HeaderClient/Header"
import SectionOne from "./components/ClientVerApp/SectionOne/SectionOne"
import Footer from "./components/ClientVerApp/Footer/Footer"
import './styles/ClientVerApp.scss'

export default function ClientVerApp () {

    const questsRef = useRef(null)

    return (
        <>
            <Header
                questsRef={questsRef}
            />
            <main className="main">
                <div className="container-main">
                    <div className="client-page">
                        <SectionOne/>
                    </div>
                </div>
            </main>
            <Footer/>
        </>
    )
}