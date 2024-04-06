import http from 'k6/http'
import { sleep } from 'k6'

export const options = {
    ext: {
        loadimpact: {
            progectID: '3690136'
        }
    },
    vus: 1,
    duration: '30s'
}

export default function () {
    http.get('https://test.k6.io')
    sleep(1)
    
    http.get('https://test.k6.io/contact')
    sleep(2)

    http.get('https://test.k6.io/news')
    sleep(2)
}