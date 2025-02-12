import { useState } from 'react'
import { useCreateQuestStore } from '../../../store/userStore/createQuestStore/createQuestStore'
import { useForm, Controller } from 'react-hook-form'
import Select from 'react-select'
import './CreateQuest.scss'

const difficultyOptions = [
    {value: "Easy", label: "Easy"},
    {value: "Medium", label: "Medium"},
    {value: "Hard", label: "Hard"},
]

export default function CreateQuest () {

    const {register,control, formState: {errors, isValid}} = useForm({
        mode: "onChange"
    })
    const {newQuest, questions, setNewQuest} = useCreateQuestStore()

    const handleOnChangeBaseField = (e) => {
        const {name, value} = e.target;
        setNewQuest({[name]: value})
    }

    const inputErrors = {
        title: {
          message: errors.title?.message || null
        },
        description: {
          message: errors.description?.message || null
        },
        difficulty: {
          message: errors.difficulty?.message || null
        },
    }

    const handleOnChangeDifficulty = (selectedOption) => {
        setNewQuest({difficulty: selectedOption ? selectedOption.value : null})
    }

    return (
        <>
            <div className="wrapper-create-page">
                <div className="create-page">
                    <div className="create-page-title">
                        <h3 className='create-page-title__h3'>
                            Create Your Quest
                        </h3>
                    </div>
                    <div className="create-page-base">
                        <BasePageField
                            name={"title"}
                            type={"text"}
                            value={newQuest.title || ""}
                            label={"Quest Name:"}
                            register={register}
                            validationRules={{
                                required: 'This field must not be empty'
                            }}
                            inputErrors={inputErrors}
                            onChange={handleOnChangeBaseField}
                        />
                        <BasePageField
                            name={"description"}
                            type={"text"}
                            value={newQuest.description || ""}
                            label={"Quest Description:"}
                            register={register}
                            validationRules={{
                                required: 'This field must not be empty'
                            }}
                            inputErrors={inputErrors}
                            onChange={handleOnChangeBaseField}
                        />
                        <div className='create-field-base'>
                            <p className='create-field-base__p'>
                                Quest Difficulty:
                            </p>
                            <Controller
                                name='difficulty'
                                control={control}
                                defaultValue={newQuest.difficulty || ""}
                                rules={{ required: 'This field must not be empty' }}
                                render={(({field}) => (
                                    <Select
                                        {...field}
                                        value={newQuest.difficulty ? {value: newQuest.difficulty, label: newQuest.difficulty} : null}
                                        onChange={handleOnChangeDifficulty}
                                        options={difficultyOptions}
                                        placeholder={"Select a difficulty..."}
                                        isSearchable
                                        isClearable
                                        menuPortalTarget={document.body}
                                        classNamePrefix='create-field-base__select'
                                    />
                                ))}
                            />
                            {inputErrors.difficulty && <p className="create-field-base__error">{inputErrors.difficulty.message}</p>}
                        </div>
                    </div>
                    <div className='create-page-main'>
                        <div className='create-page-main__title'>
                            <h3 className='create-page-main__title__h3'>Add your Questions</h3>
                        </div>
                        <div className='create-page-main-questions-wrapper'>
                            {
                                questions.map((question) => {
                                    return (
                                        <BlockQuest
                                            key={question.id}
                                            question={question}
                                        />
                                    )
                                })
                            }
                        </div>
                        <div className='create-main-button'>
                            <button>Add one</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

function BasePageField ({register, value, inputErrors, type, label, name, validationRules, onChange}) {

    const fieldError = inputErrors?.[name]?.message

    return (
        <>
            <div className="create-field-base">
                <label className='create-field-base__label' htmlFor={label}>{label}</label>
                <input value={value} className='create-field-base__input' type={type} name={name} id={label}
                    {...register(name, {
                        ...validationRules,
                        onChange: (e) => onChange(e)
                    })}
                />
                {fieldError && <p className='create-field-base__error'>{fieldError}</p>}
            </div>
        </>
    )
}

function BlockQuest ({question}) {
    return (
        <>

        </>
    )
}