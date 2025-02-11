import { Link } from 'react-router-dom'
import { useUserInformationStore } from '../../../store/userStore/userInformationStore/userInformationStore'
import iconMenu from '../../../assets/img/icons/headerUserVer/menu.png'
import logo from '../../../assets/img/logo/logo.png'
import './Header.scss'

export default function Header ({handleOnClickOpenSidebar}) {

    const {userData, setUserData} = useUserInformationStore()

    return (
        <>
            <div className="wrapper-header-userver">
                <header className="header-userver">
                    <div className="header-userver__title">
                        <div onClick={handleOnClickOpenSidebar} className="header-userver__title__menu">
                            <img src={iconMenu} alt="menu_icon" className='header-userver__title__menu__img'/>
                        </div>
                        <Link to={'/app'} className='header-userver__title_main'>
                           <img src={logo} alt="logo_icon" className='header-userver__title_main__img'/>
                            <h3 className='header-userver__title_main__h3'>
                                APIQuest
                            </h3> 
                        </Link>
                    </div>
                    <Link to={`/app/user/${userData.name}`} className="header-userver__button">
                        <img src="https://fakeimg.pl/300/" alt="avatar_icon"  className='header-userver__button__img'/>
                    </Link>
                </header>
            </div>
        </>
    )
}