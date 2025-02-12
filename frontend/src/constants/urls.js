export const BASE_URL = import.meta.env.VITE_backBaseUrl

export const urls = {
    QUESTS: {
        GET: `${BASE_URL}/Tests`,
        GET_BY_ID: `${BASE_URL}/Tests/:questId`,
    }
}