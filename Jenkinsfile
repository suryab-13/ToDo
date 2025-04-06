pipeline {
    agent any

    environment {
        IMAGE_NAME = 'todo-app'
        DOCKER_TAG = 'latest'
        BUILD_CONFIGURATION = 'Release'
        CONTAINER_NAME = 'todo-container'
        HOST_PORT = '5000'
        CONTAINER_PORT = '8080'
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/suryab-13/ToDo.git'
            }
        }

        stage('Check Docker') {
            steps {
                sh 'docker --version'
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    sh "docker build --build-arg BUILD_CONFIGURATION=${BUILD_CONFIGURATION} -t ${IMAGE_NAME}:${DOCKER_TAG} ."
                }
            }
        }

        stage('Verify Image (Optional)') {
            steps {
                sh 'docker images | grep todo-app'
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Stop & remove old container if running
                    sh """
                    docker rm -f ${CONTAINER_NAME} || true
                    docker run -d --name ${CONTAINER_NAME} -p ${HOST_PORT}:${CONTAINER_PORT} ${IMAGE_NAME}:${DOCKER_TAG}
                    """
                }
            }
        }
    }

    post {
        success {
            echo "Build and run complete. Access the app at http://localhost:${HOST_PORT}"
        }
        failure {
            echo "Build or run failed."
        }
        always {
            cleanWs()
        }
    }
}
