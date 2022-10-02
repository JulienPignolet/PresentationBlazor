import fx from 'fireworks'

window.Fireworks = () => {
    let range = n => [...new Array(n)]

    range(6).map(() =>
        fx({
            x: Math.random(10) + 200,
            y: Math.random(10) + 200,
            canvasWidth: window.innerWidth,
            canvasHeight: window.innerHeight,
            colors: ['#B243B6', '#F363B1', '#FDBF3B', '#F7F570', '#93EE81', '#47D4C4']
        })
    )
}