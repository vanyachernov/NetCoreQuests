import { useState, useEffect } from "react"
import { Link } from "react-router-dom";
import { useQuestsStore } from "../../../store/userStore/questsStore/questsStore.js"
import Rating from '@mui/material/Rating';
import arrowPrev from '../../../assets/img/icons/arrow-prev.png'
import arrowNext from '../../../assets/img/icons/arrow-next.png'
import './Quests.scss'

export default function Quests () {

    const {quests, fetchQuests} = useQuestsStore()
    const [currentPage, setCurrentPage] = useState(1)
    const questsPerPage = 5

    useEffect(() => {
        fetchQuests()
    },[])

    const indexOfLastProduct = currentPage * questsPerPage;
    const indexOfFirstProduct = indexOfLastProduct - questsPerPage;
    const currentQuests = quests.slice(indexOfFirstProduct, indexOfLastProduct)

    const handleOnClickPaginate = (number) => {
        setCurrentPage(number)
    }


    return (
        <>
            <div className="wrapper-quests">
                <div className="quests-title">
                    <h3 className="quests-title__h3">
                        Quests
                    </h3>
                    <p className="quests-title__p">
                        On this page, you can complete quests with text, images, and videos.
                    </p>
                </div>
                <div className="quests">
                    {
                        currentQuests.map((quest) => {
                            return (
                                <QuestItem
                                    key={quest.id}
                                    quest={quest}
                                />
                            )
                        })
                    }
                </div>
                <Paginations
                    questsPerPage={questsPerPage}
                    totalQuests={quests.length}
                    currentPage={currentPage}
                    handleOnClickPaginate={handleOnClickPaginate}
                    setCurrentPage={setCurrentPage}
                />
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
                            {quest.name}
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
                    <Link to={`/app/quest/${quest.id}`} className="section-two__quest-item-main__link">
                        View
                    </Link>
                </div>
            </div>
        </>
    )
}

function Paginations ({questsPerPage, totalQuests, currentPage, handleOnClickPaginate, setCurrentPage}) {

    const questsNumbers = []

    for (let i = 1; i <= Math.ceil(totalQuests / questsPerPage); i++) {
        questsNumbers.push(i)
    }

    const handleClickButtonPrevArrow = () => setCurrentPage(prev => prev - 1)
    const handleClickButtonNextArrow = () => setCurrentPage(prev => prev + 1)

    return (
        <>
            <div className='paginations'>
                { 
                    currentPage != 1 ? <img onClick={handleClickButtonPrevArrow} className='paginations-arrow__img' src={arrowPrev} alt="prev-arrow" /> : ''
                }
                <ul className='paginations-list'> 
                    {
                        questsNumbers.map((number) => {
                            return (
                                <li key={number} onClick={() => handleOnClickPaginate(number)} className='paginations-list-item'>
                                    {number}
                                </li>
                            )
                        })
                    }
                </ul>
                {
                    currentPage != questsNumbers.length ? <img onClick={handleClickButtonNextArrow} className='paginations-arrow__img' src={arrowNext} alt="next-arrow" /> : ''
                }
            </div>
        </>
    )
}