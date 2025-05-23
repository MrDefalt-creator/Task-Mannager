﻿import {useState} from "react";

export default function ElementOfList({task,isSelected, onSelect}){
    const [hovered, setHovered] = useState(false)
    return (
        <section className="block w-[80%] border-[1px] border-gray-300 rounded-xl overflow-hidden">
            <div
                onMouseEnter={() => setHovered(true)}
                onMouseLeave={() => setHovered(false)}
                onClick={onSelect}
                className={`flex items-center justify-center p-3 rounded-xl ${isSelected ? "bg-violet-500 text-white" : hovered ? "bg-violet-200" : "bg-white"}`}
            >
                <h4 className="font-sans font-medium text-base">{task.title}</h4>
            </div>
        </section>
    )
}