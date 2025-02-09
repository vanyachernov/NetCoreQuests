import { useRef, useEffect } from "react"
import { Link } from "react-router-dom"
import logo from '../../../assets/img/logo/logo.png'
import './Header.scss'

export default function Header ({questsRef}) {

    const headerRef = useRef(null)
    const navItems = ["Quests"]

    const handleOnClickNavItem = () => {
        if (questsRef.current) {
            const headerHeight = headerRef.current?.offsetHeight || 0;
            window.scrollTo({
                top: questsRef.current.offsetTop - headerHeight,
                behavior: "smooth",
            })
        }
    }

    const handleOnClickLogo = () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth",
        })
    }

    useEffect(() => {
        const handleScroll = () => {
            if (window.scrollY > 50) {
                headerRef.current?.classList.add("scrolled")
            } else {
                headerRef.current?.classList.remove("scrolled")
            }
        } 
        window.addEventListener("scroll", handleScroll)
        return () => {
            window.removeEventListener("scroll", handleScroll)
        }
    },[])

    return (
        <>
            <header ref={headerRef} className="header">
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
                        <div onClick={handleOnClickLogo} className="logo">
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