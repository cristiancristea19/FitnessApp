import React from 'react'
import ReactModal from 'react-modal'
import DeleteWorkoutRecord from '../Api/DeleteWorkoutRecord'
import Button from './Button'

const ConfirmationMessageModal = ({
    text,
    isOpen,
    setOpen,
    workoutId,
    refreshPage,
    buttonText
}) => {

    const deleteWorkoutRecord = async () => {
        await DeleteWorkoutRecord(workoutId);
        refreshPage();
        closeModal();
    }

    const closeModal = () => {
        setOpen(false);
    }

    return (
        <ReactModal
            isOpen={isOpen}
            style={{
                overlay: {
                    backgroundColor: '#00000078'
                },
                content: {
                    borderRadius: '20px',
                    margin: 'auto',
                    height: '120px',
                    width: '500px',
                    padding: '20px'
                }
            }}
            ariaHideApp={false}
        >
            <h1 className='category-title'>
                {text}
            </h1>
            <div className='btn-container'>
                <Button
                    text="Cancel"
                    onClickFunction={closeModal}
                />
                <Button
                    text={buttonText}
                    onClickFunction={deleteWorkoutRecord}
                />
            </div>
        </ReactModal>
    )
}

export default ConfirmationMessageModal