import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import {useQuestsStore} from '../../../store/clientStore/questsStore/questsStore.js'
import {BeatLoader} from 'react-spinners'
import './SectionTwo.scss'

const quests = [
    {
        id: 1,
        name: 'Lorem ipsum dolor sit amet',
        title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
        img: 'https://fakeimg.pl/800/',
    },
    {
        id: 2,
        name: 'Lorem ipsum dolor sit amet',
        title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
        img: 'https://fakeimg.pl/600/',
    },
    {
        id: 3,
        name: 'Lorem ipsum dolor sit amet',
        title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
        img: 'https://fakeimg.pl/600/',
    },
    {
        id: 4,
        name: 'Lorem ipsum dolor sit amet',
        title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
        img: 'https://fakeimg.pl/600/',
    },
]

export default function SectionTwo ({questsRef}) {

    const {isLoading} = useQuestsStore()

    return (
        <>
            <div ref={questsRef} className="section-two-wrapper"> 
                <div className="section-two">
                    <div className="section-two-title">
                        <h3 className="section-two-title__h3">
                            Available Quests
                        </h3>
                        <p className="section-two-title__p">
                            Create, play, and track custom quests with real-time updates and ratings.
                        </p>
                        <div className="section-two-line"></div>
                    </div>
                    <div className="section-two-quests">
                        {
                            isLoading ? (
                                <div className="section-two-loading">
                                    <BeatLoader size={17} color="#fff" />
                                </div>
                            ) : (
                                quests.map((quest) => (
                                    <QuestItem key={quest.id} quest={quest} />
                                ))
                            )
                        }
                    </div>
                    {/* <div className="section-two-addNew">
                        <h3 className="section-two-addNew__h3">
                            Create Your Quest
                        </h3>
                        <p className="section-two-addNew__p">
                            Sign in and start creating your quest!
                        </p>
                        <Link className="section-two-addNew__link" to={'/login'}>
                            Login
                        </Link>
                    </div> */}
                </div>
            </div>
        </>
    )
}

function QuestItem ({quest}) {
    return (
        <>
            <div className="section-two__quest-item">
                <div className="section-two__quest-item__img">
                    <img src={quest.img} alt="quest_image"/>
                </div>
                <div className="section-two__quest-item-main">
                    <h3 className="section-two__quest-item-main__h3">
                        {quest.name}
                    </h3>
                    <Link to={''} className="section-two__quest-item-main__link">
                        View
                    </Link>
                </div>
            </div>
        </>
    )
}
