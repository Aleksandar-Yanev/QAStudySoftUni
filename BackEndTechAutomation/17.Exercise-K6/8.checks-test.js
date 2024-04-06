import http from 'k6/http'
import { sleep, check } from 'k6'

export default function() {
    const response = http.get('https://test.k6.io')
    check (response, {
        'HTTP status is OK': (r) => r.status === 200,
        'Home page welcome message is': (r) => r.body.includes('Welcome to the k6.io demo site!')
    })
    sleep(1)
}