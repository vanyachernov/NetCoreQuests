import { useEffect, useState } from 'react'
import { useUserInformationStore } from '../../../store/userStore/userInformationStore/userInformationStore.js'
import {StyledMain as SM} from './StyledUserPanel'
import './UserPanel.scss'


const tabsItem = ["Your Information", "Quests History", "Achievements"]

export default function UserPanel () {

    const [currentTab, setCurrentTab] = useState(0)

    return (
        <>
            <SM.WrapperUserPanel>
                <SM.UserPanel>
                    <SM.WrapperTabs>
                        {
                            tabsItem.map((item, index) => {
                                return (
                                    <TabsItem
                                        key={item}
                                        itemName={item}
                                        index={index}
                                        currentTab={currentTab}
                                        setCurrentTab={setCurrentTab}
                                    />
                                )
                            })
                        }
                    </SM.WrapperTabs>
                    <div className="wrapper-tabs-content">
                        {currentTab === 0 && <TabsContentOne/>}
                        {currentTab === 1 && <TabsContentTwo/>}
                    </div>
                </SM.UserPanel>
            </SM.WrapperUserPanel>
        </>
    )
}

function TabsItem ({itemName, index,currentTab, setCurrentTab}) {
    return (
        <>
            <li className={`tabs-item ${currentTab === index ? "active-tab" : ""}`} onClick={() => setCurrentTab(index)}>
                {itemName}
            </li>
        </>
    )
}

function TabsContentOne () {

    const [editButton, setEditButton] = useState(true)
    const {userData, setUserData} = useUserInformationStore()

    const toggleEditMode = () => {
        setEditButton(!editButton)
    }

    const handleOnChangeFields = (e) => {
        setUserData({
            [e.target.name]: e.target.value
        })
    }

    const handleEditButtonClick = () => {
        
        toggleEditMode()
    }

    return (
        <>
            <div className='tab-one'>
                <div className='tab-one-image'>
                    <img className='tab-one-image__img' src="https://fakeimg.pl/500/" alt="user_icon" />
                </div>
                <div className='tab-one-userInfo'>
                    <div className='tab-one-userInfo__title'>
                        <h3 className="tab-one-userInfo__title__h3">
                            Information
                        </h3>
                    </div>
                    <div className='tab-one-userInfo-page'>
                        <UserFieldInfo
                            label={"First Name"}
                            value={userData.decodeToken.userFirstName}
                            name={"name"}
                            editButton={editButton}
                            type={"text"}
                            onChange={handleOnChangeFields}
                        />
                        <UserFieldInfo
                            label={"Last Name"}
                            value={userData.decodeToken.userLastname}
                            name={"lastName"}
                            editButton={editButton}
                            type={"email"}
                            onChange={handleOnChangeFields}
                        />
                        <UserFieldInfo
                            label={"Email"}
                            value={userData.decodeToken.userEmail}
                            name={"email"}
                            editButton={editButton}
                            type={"email"}
                            onChange={handleOnChangeFields}
                        />
                    </div>
                    <div className="tab-one-userInfo-button">
                        <button onClick={handleEditButtonClick} className='tab-one-userInfo-button__button'>
                            {editButton ? "Edit" : "Save"}
                        </button>
                    </div>
                </div>
            </div>
        </>
    )
}

function UserFieldInfo ({label,editButton, type, value, name, onChange}) {
    return (
        <>
            <p className="tab-one-userInfo-page__p">
                {label}: {!editButton ? <input onChange={onChange} autoComplete='off' className='tab-one-userInfo-page__input' name={name} value={value || ""} type={type}/> : value || `${label} is not available`}
            </p>
        </>
    )
}

function TabsContentTwo () {
    return (
        <>
        
        </>
    )
}