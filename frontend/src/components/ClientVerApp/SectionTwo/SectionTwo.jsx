import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import {useQuestsStore} from '../../../store/clientStore/questsStore/questsStore.js'
import {BeatLoader} from 'react-spinners'
import Rating from '@mui/material/Rating';
import './SectionTwo.scss'

// const quests = [
//     {
//         id: 1,
//         name: 'Lorem ipsum dolor sit amet',
//         title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
//         img: 'https://fakeimg.pl/800/',
//         rating: 3,
//     },
//     {
//         id: 2,
//         name: 'Lorem ipsum dolor sit amet',
//         title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
//         img: 'https://fakeimg.pl/600/',
//         rating: 2,
//     },
//     {
//         id: 3,
//         name: 'Lorem ipsum dolor sit amet',
//         title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
//         img: 'https://fakeimg.pl/600/',
//         rating: 4,
//     },
//     {
//         id: 4,
//         name: 'Lorem ipsum dolor sit amet',
//         title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
//         img: 'https://fakeimg.pl/600/',
//         rating: 3,
//     },
// ]

export default function SectionTwo ({questsRef}) {

    // const {isLoading} = useQuestsStore()
    const {quests, fetchQuests, isLoading} = useQuestsStore()

    useEffect(() => {
        fetchQuests()
    },[])

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
                    <img src="https://fakeimg.pl/600/" alt="quest_image"/>
                </div>
                <div className="section-two__quest-item-main">
                    <div className="section-two__quest-item-title">
                        <h3 className="section-two__quest-item-title__h3">
                            {quest.title}
                        </h3>
                        <div className="section-two__quest-item-title__rating">
                            <Rating 
                                sx={{
                                    width: '120px',
                                    "& .MuiRating-iconEmpty": {
                                        color: "#fff",
                                    },
                                }} 
                                size="medium" 
                                name="rating-read" 
                                max={5} 
                                value={quest.rating || 0}
                                readOnly
                            />
                        </div>
                    </div>
                    <Link to={`/quest/${quest.id}`} className="section-two__quest-item-main__link">
                        View
                    </Link>
                </div>
            </div>
        </>
    )
}
