pipeline {
    agent any

    environment {
        IMAGE_NAME = 'todo-app'
        DOCKER_TAG = 'latest'
        BUILD_CONFIGURATION = 'Release'
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/yourusername/your-repo.git' // Replace with your actual repo
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    sh "docker build --build-arg BUILD_CONFIGURATION=${BUILD_CONFIGURATION} -t ${IMAGE_NAME}:${DOCKER_TAG} ./ToDo"
                }
            }
        }

        stage('Verify Image (Optional)') {
            steps {
                sh 'docker images | grep todo-app'
            }
        }
    }

    post {
        success {
            echo "Build complete. Docker image '${IMAGE_NAME}:${DOCKER_TAG}' is ready locally."
        }
        failure {
            echo "Build failed."
        }
    }
}
