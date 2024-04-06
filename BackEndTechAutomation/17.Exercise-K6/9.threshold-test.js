import http from 'k6/http'
import { sleep, check } from 'k6'

export const options = {
    vus: 10,
    duration: '30s',
    thresholds: {
        'http_req_duration': ['p(95)<350', 'p(90)<320'],
        'http_req_failed': ['rate<0.01']
    }
}

export default function() {
    const response = http.get('https://test.k6.io')
    check (response, {
        'HTTP status is OK': (r) => r.status === 200,
        'Home page welcome message is': (r) => r.body.includes('Welcome to the k6.io demo site!')
    })
    sleep(1)
}