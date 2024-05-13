import { createContext, useState, useEffect, useContext } from 'react'
import axios from 'axios'

const StatusCountContext = createContext();

const StatusCountContextComponent = (props) => {
    const [pendingCount, setPendingCount] = useState(0)

    const [acceptedCount, setAcceptedCount] = useState(0)

    const [declinedCount, setDeclinedCount] = useState(0)



    const refreshPendingCount = async () => {
        const { data } = await axios.get('/api/Candidates/getpendingcount')
        setPendingCount(data)
    }

    const refreshAcceptedCount = async () => {
        const { data } = await axios.get('/api/Candidates/getacceptedcount')
        setAcceptedCount(data)
    }

    const refreshDeclinedCount = async () => {
        const { data } = await axios.get('/api/Candidates/getdeclinedcount')
        setDeclinedCount(data)
    }


    useEffect(() => {
        refreshPendingCount()
        refreshAcceptedCount()
        refreshDeclinedCount()
    }, [])

    const obj = {
        pendingCount,
        acceptedCount,
        declinedCount,
        refreshPendingCount,
        refreshAcceptedCount,
        refreshDeclinedCount
    }

    return <StatusCountContext.Provider value={obj}>
        {props.children}
    </StatusCountContext.Provider>
}

const useStatusCount = () => {
    return useContext(StatusCountContext)
}

export default StatusCountContextComponent
export { useStatusCount }