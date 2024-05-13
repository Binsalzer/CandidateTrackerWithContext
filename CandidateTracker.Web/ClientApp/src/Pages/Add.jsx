import React, { useState } from 'react'
import { useStatusCount } from '../StatusCountContext'
import axios from 'axios'

const Add = () => {
    const { refreshPendingCount } = useStatusCount()

    const [candidate, setCandidate] = useState({
        name: '',
        email: '',
        phone: '',
        notes: '',
        status:'pending'
    })
    const onUpdateStateClick = () => {
        const c = {
            name: 'test 100',
            email: '100@test.com',
            phone: '100',
            notes: 'jufyjyfjfk  fuyj fyuj yfj t',
            status: 'pending'
        }
        setCandidate(c)
    }

    const onSubmitClick = async() => {
        await axios.post('/api/candidates/addpending', candidate)
        refreshPendingCount()
    }

    return (
        <div>
            <button className='btn btn-success' onClick={onUpdateStateClick}>_____</button>
            <button className='btn btn-success' onClick={onSubmitClick }>submit</button>
        </div>
    )
}

export default Add