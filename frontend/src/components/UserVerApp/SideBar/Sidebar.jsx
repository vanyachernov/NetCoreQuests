import { Link } from 'react-router-dom'
import logo from '../../../assets/img/logo/logo.png'
import cross from '../../../assets/img/icons/headerUserVer/cross.png'
import './Sidebar.scss'

const sidebarMenu = [
    {item: "Quests", path: "quests"},
    {item: "Create quest", path: "create"},
    {item: "Achievements", path: "achievements"},
]

export default function Sidebar ({isActiveSidebar, handleOnClickOpenSidebar}) {

    return (
        <>
            {isActiveSidebar && (
                <div className="overlay-sidebar" onClick={handleOnClickOpenSidebar}></div>
            )}
            <div className={`sidebar ${isActiveSidebar ? "open" : ""}`}>
                <div className="sidebar-title">
                    <img src={logo} alt="logo" className='sidebar-title__img-1'/>
                    <img onClick={handleOnClickOpenSidebar} src={cross} alt="cross" className='sidebar-title__img-2'/>
                </div>
                <div className='sidebar-menu'>
                    {
                        sidebarMenu.map(({item, path}) => (
                            <Link to={`/app/${path}`} key={item} className='sidebar-menu__item'>
                                {item}
                            </Link>
                        ))
                    }
                </div>
            </div>  
        </>
    )
}