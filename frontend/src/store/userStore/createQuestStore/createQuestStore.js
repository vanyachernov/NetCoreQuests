import { create } from "zustand";

export const useCreateQuestStore = create((set) => ({
    newQuest: {},
    questions: [
        {id: Date.now(), text: "", options: [
            {text: "", isTrue: false},
            {text: "", isTrue: false}
        ]}
    ],
    setNewQuest: (updateNewQuest) => {
        set((state) => ({
            newQuest: {
                ...state.newQuest,
                ...updateNewQuest
            }
        }))
    },
    setQuestions: (newQuestion) => {
        set(() => ({
            questions: newQuestion
        }))
    }
}))