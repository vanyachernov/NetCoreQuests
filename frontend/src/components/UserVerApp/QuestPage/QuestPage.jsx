import { useEffect } from 'react';
import { useQuestsStore } from '../../../store/clientStore/questsStore/questsStore.js';
import { Link, useParams, useNavigate } from 'react-router-dom';
import iconArrow from '../../../assets/img/icons/arrow-prev.png'
import Rating from '@mui/material/Rating';
import './QuestPage.scss'

export default function QuestPage () {

    const {currentQuest, fetchQuestById} = useQuestsStore()
    const {questId} = useParams()
    const navigate = useNavigate()

    useEffect(() => {
        fetchQuestById(questId)
    }, [])

    const handleOnClickArrow = () => {
        navigate(-1)
    }

    return (
        <>
            <div className="wrapper-quest-page">
                <div className="quest-page">
                    <div className='quest-page-img'>
                        <img src="https://fakeimg.pl/600/" alt="img_quest" className='quest-page-img__img'/>
                    </div>
                    <div className='quest-page-main'>
                        <div className="quest-page-main-title">
                            <img onClick={handleOnClickArrow} src={iconArrow} alt="arrow-prev" className='quest-page-main-title__img'/>
                            <h3 className='quest-page-main-title__h3'>
                                {currentQuest.title}
                            </h3>
                        </div>
                        <div className="quest-page-main-description">
                            <div className="quest-page-main-description__title">
                                <h3 className='quest-page-main-title__h3'>
                                    {currentQuest.description}
                                </h3>
                            </div>
                            <div className="quest-page-main-description__rating">
                                <Rating 
                                    sx={{
                                        width: '120px',
                                        "& .MuiRating-iconEmpty": {
                                            color: "#fff",
                                        },
                                    }} 
                                    size="medium" 
                                    name="quest-page-rating-read" 
                                    max={5} 
                                    value={currentQuest.rating || 3}
                                    readOnly
                                />
                            </div>
                        </div>
                        <div className="quest-page-main__buttons">
                            <Link className='quest-page-main__buttons__link'>
                                Play
                            </Link>
                            {currentQuest.difficulty === "Easy" && 
                            <p className='quest-page-main__buttons__p'>
                                Difficulty level: <span className='quest-page-main__buttons__span-easy'>{currentQuest.difficulty}</span>
                            </p>}
                            {currentQuest.difficulty === "Medium" && 
                            <p className='quest-page-main__buttons__p'>
                                Difficulty level: <span className='quest-page-main__buttons__span-medium'>{currentQuest.difficulty}</span>
                            </p>}
                            {currentQuest.difficulty === "Hard" && 
                            <p className='quest-page-main__buttons__p'>
                                Difficulty level: <span className='quest-page-main__buttons__span-hard'>{currentQuest.difficulty}</span>
                            </p>}
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}