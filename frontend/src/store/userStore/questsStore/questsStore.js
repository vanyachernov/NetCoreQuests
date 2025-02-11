import { create } from "zustand";
import axios from "axios";

export const useQuestsStore = create((set) => ({
    quests: [
        {
            id: 1,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/800/',
            rating: 3,
        },
        {
            id: 2,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 2,
        },
        {
            id: 3,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 4,
        },
        {
            id: 4,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 5,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 6,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 7,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 8,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 9,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 10,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 11,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 12,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 13,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
        {
            id: 14,
            name: 'Lorem ipsum dolor sit amet',
            title: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Illo rerum incidunt, earum hic in neque dolorum, similique placeat sequi corporis consequuntur.',
            img: 'https://fakeimg.pl/600/',
            rating: 3,
        },
    ],
    fetchQuests: async () => {
        try {
            
        } catch (error) {
            
        }
    }
}))