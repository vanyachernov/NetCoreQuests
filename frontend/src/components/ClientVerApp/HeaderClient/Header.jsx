import { Link } from "react-router-dom"
import logo from '../../../assets/img/logo/logo.png'
import './Header.scss'

export default function Header ({questsRef}) {

    const navItems = ["Quests"]

    const handleOnClickNavItem = () => {
        questsRef.current?.scrollIntoView({ behavior: "smooth", block: "start" })
    }

    return (
        <>
            <header className="header">
                <div className="container">
                    <div className="header_row">
                        <nav className="nav">
                            <ul className="menu">
                                {
                                    navItems.map((item) => (
                                        <li key={item} onClick={handleOnClickNavItem} className="menu-item">
                                            {item}
                                        </li>
                                    ))
                                }
                            </ul>
                        </nav>
                        <div className="logo">
                            <img src={logo} alt="logo" className="logo__img"/>
                        </div>
                        <div className="header-buttons">
                            <Link to={'/login'} className="header-buttons__button">
                                Login
                            </Link>
                        </div>
                    </div>
                </div>
            </header>
        </>
    )
}