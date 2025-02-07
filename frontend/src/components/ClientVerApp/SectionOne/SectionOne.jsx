import { Link } from "react-router-dom"
import './SectionOne.scss'

export default function SectionOne () {
    return (
        <>
            <section className="section-one-wrapper">
                <div className="section-one">
                    <div className="section-one-title">
                        <h3 className="section-one-title__h3">
                            Welcome to YourQuest
                        </h3>
                    </div>
                    <div className="section-one-main">
                        <p className="section-one-main__p">
                            YourQuests is a web platform where users can create, customize, and complete quests with various challenges. Quests can include text, images, and videos, and can be played individually or in groups. The platform features registration, a rating system, a chat for participants, and real-time updates. Join now and start your adventure — just click the button below to sign up!
                        </p>
                    </div>
                    <div className="section-one-button">
                        <Link to={'/login'} className="section-one-button__link">
                            Login
                        </Link>
                    </div>
                </div>
            </section>
        </>
    )
}